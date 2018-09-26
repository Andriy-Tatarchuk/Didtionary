﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Translate.v2;
using Google.Cloud.Translation.V2;

namespace Enigma.Translate
{
    public class Translator
    {
        public string Translate(string word)
        {
            var result = string.Empty;
            try
            {
                var credential = GoogleCredential.FromFile("C:\\Users\\Andriy.Tatarchuk\\Documents\\GitHub\\Enigma-5f1206253fa8.json");
                var client = TranslationClient.Create(credential);
                var translaterResult = client.TranslateText(word, LanguageCodes.English);
                result = translaterResult.TranslatedText;
            }
            catch (Exception e)
            {

            }

            return result;
        }
    }
}
