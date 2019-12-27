using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace ConsumeSoap.RestApi
{
    public class SoapAuthHeader
    {
        public static void Create(string username, string password)
        {

            //Add a HTTP Soap Header to an out going request
            String auth = "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(username+":"+ password));
            HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
            requestMessage.Headers.Add("Authorization", auth);

            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;


        }

    }
}
