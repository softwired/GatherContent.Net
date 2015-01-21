using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GatherContent.Net
{
    public class GatherContentClient
    {
        private readonly string _accountName;
        private readonly string _apiKey;
        private readonly string _version;

        public GatherContentClient(string accountName, string apiKey, string version = "0.4")
        {
            _accountName = accountName;
            _apiKey = apiKey;
            _version = version;
        }


        public ProjectData GetProjects()
        {
            return GetProjectsAsync().Result;
        }

        public async Task<ProjectData> GetProjectsAsync()
        {
            return await PostAsync<ProjectData>("get_projects");
        }

        public PageItem GetPage(string pageID) {
            return GetPageAsync(pageID).Result;
        }

        public async Task<PageItem> GetPageAsync(string pageID) {
            var result = await PostAsync<PageItem>("get_page", new[] { new KeyValuePair<string, string>("id", pageID) });
            if (result.page != null) {
                result.page.SetContents();
            }
            return result;
        }

        public PageData GetPagesByProject(string projectId)
        {
            return GetPagesByProjectAsync(projectId).Result;
        }

        public async Task<PageData> GetPagesByProjectAsync(string projectId)
        {
            var result = await PostAsync<PageData>("get_pages_by_project", new[] { new KeyValuePair<string, string>("id", projectId) });
            if (result.pages != null) {
                foreach (var page in result.pages) {
                    page.SetContents();
                }
            }
            return result;
        }

        public FileData GetFilesByProject(string projectId)
        {
            return GetFilesByProjectAsync(projectId).Result;
        }

        public async Task<FileData> GetFilesByProjectAsync(string projectId)
        {
            return await PostAsync<FileData>("get_files_by_project", new[] { new KeyValuePair<string, string>("id", projectId) });
        }

        public Stream DownloadFile(string fileName)
        {
            return DownloadFileAsync(fileName).Result;
        }


        public async Task<Stream> DownloadFileAsync(string fileName)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://gathercontent.s3.amazonaws.com");

                var result = await httpClient.GetAsync(fileName);
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    return await result.Content.ReadAsStreamAsync();
                }
                return null;
            }
        }

        private async Task<T> PostAsync<T>(string requestUri, IEnumerable<KeyValuePair<string, string>> parameters = null)
        {
            var baseAddress = new Uri(string.Format("https://{0}.gathercontent.com/api/{1}/", _accountName, _version));
            var credentialCache = new CredentialCache {{baseAddress, "Digest", new NetworkCredential(_apiKey, "x")}};
            using (var httpClient = new HttpClient(new HttpClientHandler { Credentials = credentialCache }))
            {
                {
                    httpClient.BaseAddress = baseAddress;

                    var result = await httpClient.PostAsync(requestUri, new FormUrlEncodedContent(parameters ?? new HashSet<KeyValuePair<string, string>>()));

                    var response = await result.Content.ReadAsStringAsync();

                    return await JsonConvert.DeserializeObjectAsync<T>(response);
                }
            }
        }

    }
}
