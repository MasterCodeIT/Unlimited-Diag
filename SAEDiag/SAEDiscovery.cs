﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using J2534;

namespace SAE
{
    public class SAEDiscovery
    {
        public static List<J1979Session> ConnectEverything(List<J2534PhysicalDevice> Devices)
        {
            List<J1979Session> Sessions = new List<J1979Session>();
            foreach(J2534PhysicalDevice Device in Devices)
            {
                foreach(Channel SAEChannel in new SAEProtocols(Device))
                {
                    J1979Session Session = new J1979Session(SAEChannel, true);
                    if(Session.Broadcast())
                        Sessions.Add(Session);
                }
            }
            return Sessions;
        }
    }
}
