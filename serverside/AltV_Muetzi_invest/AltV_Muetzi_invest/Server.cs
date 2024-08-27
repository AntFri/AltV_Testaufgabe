using AltV.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltV_Muetzi_invest
{
    public class Server : Resource
    {
        public override void OnStart()
        {
            Alt.Log("Server wurde Gestartet");
            
        }
        public override void OnStop()
        {
            Alt.Log("Server wurde Gestopt");
            
        }
    }
}
