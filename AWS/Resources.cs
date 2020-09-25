using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AWS
{
     public class Resources
    {
        public Resources() { 

        
        }

        public string GetScript(int providerId, string[] resourcenames)
        {
            try
            {
                StringBuilder resourceScripts = new StringBuilder();
                LoadFile();
                var resources = GetResourceScript();

                if (providerId == 1)
                {

                    foreach (AWSResources resource in resources) {
                        if (resourcenames[0].ToString()== resource.resourceName)
                        {
                            resourceScripts.Append(resource.resourceScript);
                        }


                }
                }

                return resourceScripts.ToString();
            }
            catch (Exception Ex)
            {

                return Ex.Message;
            }
            //Process JSOn File
            //if (enumAWSReources.re)


        }
        private void LoadFile() {
            try
            {

                using (StreamReader r = new StreamReader("awsresource.json"))
                {
                    string json = r.ReadToEnd();
                    List<AWSResources> resources = JsonConvert.DeserializeObject<List<AWSResources>>(json);
                }

            }
            catch (Exception Ex) {
                string error = Ex.Message;            
            }
        }
        private List<AWSResources> GetResourceScript()
        {
            try
            {

                using (StreamReader r = new StreamReader("awsresource.json"))
                {
                    string json = r.ReadToEnd();
                    List<AWSResources> resources = JsonConvert.DeserializeObject<List<AWSResources>>(json);
                    return resources;
                }

            }
            catch (Exception Ex)
            {
                string error = Ex.Message;
                return null;
            }
        }
    }
}
