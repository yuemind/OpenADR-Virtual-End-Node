﻿//////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2014, Electric Power Research Institute (EPRI)
// All rights reserved.
//
// oadr2b-ven, oadrlib, and oadr-test ("this software") are licensed under the 
// BSD 3-Clause license.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//   * Redistributions of source code must retain the above copyright notice, this 
//     list of conditions and the following disclaimer.
//     
//   * Redistributions in binary form must reproduce the above copyright notice, 
//     this list of conditions and the following disclaimer in the documentation 
//     and/or other materials provided with the distribution.
//     
//   * Neither the name of EPRI nor the names of its contributors may 
//     be used to endorse or promote products derived from this software without 
//     specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
// IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
// PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oadrlib.lib.oadr2b
{
    public class CanceledReport : OadrRequest2b
    {
        public oadrCanceledReportType request;
        public oadrResponseType response;

        public CanceledReport()
            : base("oadrCanceledReport", "oadrResponse")
        {
        }

        /**********************************************************/

        public string createCanceledReport(string venID, string requestID,
            int responseCode, string resposneDescripton, List<string> pendingReportRequestIDs = null)
        {
            request = new oadrCanceledReportType();

            request.eiResponse = new EiResponseType();
            request.eiResponse.requestID = requestID;
            request.eiResponse.responseCode = responseCode.ToString();
            request.eiResponse.responseDescription = httpResponseDescription;

            request.schemaVersion = "2.0b";
            request.venID = venID;

            if (pendingReportRequestIDs != null)
            {
                int index = 0;

                request.oadrPendingReports = new string[pendingReportRequestIDs.Count];

                foreach (string reportRequestID in pendingReportRequestIDs)
                {
                    request.oadrPendingReports[index] = reportRequestID;
                    index++;
                }
            }
            else
                request.oadrPendingReports = new string[1];


            return serializeObject(request);
        }
    }
}
