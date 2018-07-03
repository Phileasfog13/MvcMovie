using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.IO;
using System.Web;
using Newtonsoft.Json.Linq;
using RestSharp.Deserializers;
using static MvcMovie.PaytweakData;

namespace MvcMovie
{
    public class wrapper
    {

   
        private IRestResponse clresponse;
        public string clTokenPaytweak;
        private string clhelloEnpoint="hello";
        private string clVerifyendPoint = "verify";
        private string clQuitEndPoint = "quit";
        private string clPostEndPoint = "sms";
        private string clApiUrl= "https://api.paytweak.com/v1/";
        private string clPublicKey;
        private string clPrivateKey;
//        private IRestRequest clRequest;
        private string clWorkToken;  // token de travail utilisé par les requetes . 

        public string scldummy;
        public int ncldummy;
        public bool bcldummy;
        private IRestClient Client;

       
// Constructeur de la classe 
// passer les clef publiques et privées de l'api 

    public wrapper(string PublicKey,string PrivateKey)
        {
            clPrivateKey = PrivateKey;
            clPublicKey = PublicKey;
 
        }

// Connexion a l'API 

        public string ApiConnect()
        {
            Client = new RestClient(clApiUrl);
            var Request = new RestRequest();
           
            Request.AddParameter("Paytweak-API-KEY", clPublicKey, ParameterType.HttpHeader);
            Request.Resource = clhelloEnpoint;
            IRestResponse<theToken> reponse= Client.Execute<theToken>(Request);
            if (reponse.IsSuccessful == false)
            {
                return "Erreur identification  clef publique: "+reponse.Content;
            }
            else
            {

                clWorkToken=Verify(Base64Encode(reponse.Data.PaytweakSecurityToken.Replace(" ", "") + clPrivateKey));
                return clWorkToken;
            }

            
        }

// fonction interne , controle des clefs 

        private  string Verify(string token)
        {
            
            var clRequestVerif = new RestRequest();
            clRequestVerif.AddParameter("Paytweak-USER-TOKEN", token, ParameterType.HttpHeader);
            clRequestVerif.Resource = clVerifyendPoint;
            IRestResponse<theToken> reponse = Client.Execute<theToken>(clRequestVerif);
            if (reponse.IsSuccessful == false)
            {
                return "Erreur identification  clef privée: " + reponse.Content;
            }
            else
            {
                return reponse.Data.PaytweakWorkToken;
            }

        }


        //Encode  B64
        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

// Deconnexion de l'API 
        public String ApiDisconnect()
        {
            var request = new RestRequest();
            request.AddHeader("Paytweak-Token", clWorkToken);
            request.Resource = clQuitEndPoint;
            clresponse = Client.Execute(request);
            if (clresponse.IsSuccessful== false){

                return "Erreur Deconnexion " + clresponse.Content;
            }
            else
            {
                return "OK";
            }
        

        }

    }
}
