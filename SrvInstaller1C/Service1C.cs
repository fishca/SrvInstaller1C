using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrvInstaller1C
{
    public class Service1C
    {
        public String Name;
        public String DisplayName;
        public String Description;
        public String PathName;
        public String User;

        public bool Debug = false;

        public String ExeFile = "";
        public String ClusterFiles = "";

        public int PortAgent = 1540;
        public int PortMngr  = 1541;

        public int PortProcessBegin = 1560;
        public int PortProcessEnd   = 1591;

        public Service1C()
        { }

        public void ParsePath()
        {
            String PathNameTemp = PathName.ToLower();

            if (PathNameTemp.Contains("-debug") || PathNameTemp.Contains("/debug"))
            {
                Debug = true;

                PathNameTemp = PathNameTemp.Replace("-debug", "");
                PathNameTemp = PathNameTemp.Replace("/debug", "");
            }

            int ind = PathNameTemp.IndexOf("ragent.exe");

            if (ind > 0)
            {
                ExeFile = PathNameTemp.Substring(0, ind + 10);
                ExeFile = ExeFile.Replace("\"", "");
            }

            ind = PathNameTemp.IndexOf("-regport");

            if (ind > 0)
            {
                String PortStr = "";
                int i = 0;
                String Simb = PathNameTemp.Substring(ind + 8 + i, 1);

                while ("0123456789 ".Contains(Simb))
                {
                    PortStr += Simb;
                    i++;
                    Simb = PathNameTemp.Substring(ind + 8 + i, 1);
                }


                try
                {
                    PortMngr = Convert.ToInt32(PortStr);
                }
                catch
                {

                }

            }


            ind = PathNameTemp.IndexOf("-port");
            if (ind > 0)
            {
                String PortStr = "";
                int i = 0;
                String Simb = PathNameTemp.Substring(ind + 5 + i, 1);

                while ("0123456789 ".Contains(Simb))
                {
                    PortStr += Simb;
                    i++;
                    Simb = PathNameTemp.Substring(ind + 5 + i, 1);
                }


                try
                {
                    PortMngr = Convert.ToInt32(PortStr);
                }
                catch
                {

                }
            }

            ind = PathNameTemp.IndexOf("-range");
            if (ind > 0)
            {
                String PortStr = "";
                int i = 0;
                String Simb = PathNameTemp.Substring(ind + 6 + i, 1);

                while ("0123456789 ".Contains(Simb))
                {
                    PortStr += Simb;
                    i++;
                    Simb = PathNameTemp.Substring(ind + 6 + i, 1);
                }


                try
                {
                    ind = PortStr.IndexOf(":");
                    PortProcessBegin = Convert.ToInt32(PortStr.Substring(0, ind));
                    PortProcessEnd = Convert.ToInt32(PortStr.Substring(ind + 1));
                }
                catch
                {

                }
            }

            ind = PathNameTemp.IndexOf("-d");
            if (ind > 0)
            {
                String PathStr = PathNameTemp.Substring(ind + 2);
                String Simb = PathStr.Substring(0, 1);

                while (" \"".Contains(Simb))
                {
                    PathStr = PathStr.Substring(2);
                    Simb = PathStr.Substring(1, 1);
                }
                ind = PathStr.IndexOf("\"");
                if (ind > 0)
                    this.ClusterFiles = PathStr.Substring(0, ind);
            }

            //А теперь финт ушами - ищем полученные строки в иходной строке и вырезаем оттуда с корректным регистром
            ind = PathName.ToLower().IndexOf(this.ExeFile);
            if (ind > 0)
                ExeFile = PathName.Substring(ind, ExeFile.Length);


            ind = PathName.ToLower().IndexOf(this.ClusterFiles);
            if (ind > 0)
                ClusterFiles = PathName.Substring(ind, ClusterFiles.Length);

            // "C:\Program Files\1cv82\8.2.17.153\bin\ragent.exe" -debug -srvc -agent 
            //             -regport 2541 -port 2540 -range 2560:2591 -d "C:\Program Files\1cv82\srvinfo"
        }

    }
}
