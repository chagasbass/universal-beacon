﻿// Copyright 2015 Andreas Jakl, Tieto Corporation. All rights reserved. 
// https://github.com/andijakl/universal-beacon 
// 
// Based on the Google Eddystone specification, 
// available under Apache License, Version 2.0 from
// https://github.com/google/eddystone
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
// 
//    http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 

using System;

namespace UniversalBeaconLibrary.Beacon
{
    public abstract class BeaconFrameBase
    {
        protected byte[] _payload;
        
        /// <summary>
        /// Note: directly setting the payload does not lead to the class re-parsing the payload
        /// into its instance variables (if applicable in the derived class).
        /// Call ParsePayload() manually from the derived class if you wish to enable this behavior.
        /// </summary>
        public byte[] Payload
        {
            get { return _payload; }
            set
            {
                if (value == null)
                {
                    _payload = null;
                    return;
                }
                _payload = new byte[value.Length];
                Array.Copy(value, _payload, value.Length);
            }
        }

        protected BeaconFrameBase()
        {
            
        }

        protected BeaconFrameBase(byte[] payload)
        {
            Payload = payload;
        }

        protected BeaconFrameBase(BeaconFrameBase other)
        {
            Payload = other.Payload;
        }

        public virtual bool IsValid()
        {
            return Payload != null;
        }
        
    }
}
