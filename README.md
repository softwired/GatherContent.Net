#GatherContent.Net

Access content programatically from a [GatherContent](https://gathercontent.com/) account using their [Developer API] (https://help.gathercontent.com/developer-api/).
.Net API for the GatherContent API

##Usage

Currently you can:
<dl>
  <dt>Projects</dt>
  <dd>Get a list of projects for your API Key</dd>
  <dt>Pages</dt>
  <dd>Get the pages for a given project</dd>
  <dt>Files</dt>
  <dd>Get the files for a given project and download them</dd>
</dl>

Example usage:

        var client = new GatherContentClient("subscription", "apikey");
        var projects = client.GetProjects();

##Licence

(The MIT License)

Copyright (c) 2013 Softwired Limited

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
