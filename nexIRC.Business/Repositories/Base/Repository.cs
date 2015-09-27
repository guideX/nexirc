using System.IO;
using System.Net;
using nexIRC.Business.Interfaces.Base;
using nexIRC.Business.Models;
using System.Collections.Generic;
using nexIRC.Business.Helpers;
using System;
using System.Reflection;
namespace nexIRC.Business.Repositories.Base {
    public abstract class Repository<T> : IRepository<T> {
        public virtual List<T> ReadIni(IniFileInputModel model) {
            var result = new List<T>();
            for (var i = 1; i <= Convert.ToInt32(IniFileHelper.ReadINI(model.Path, "Settings", "Count", "0")); i++) {
                var obj = Activator.CreateInstance(typeof(T));
                foreach (var property in typeof(T).GetProperties()) {
                    var propertyName = property.Name;
                    var value = IniFileHelper.ReadINI(model.Path, i.ToString(), propertyName, "");
                    var prop = obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
                    if (null != prop && prop.CanWrite) {
                        prop.SetValue(obj, value, null);
                    }

                }
                result.Add((T)obj);
            }
        }
    }
}
/*
namespace AsatClientService.Business.Repositories.Base {
    /// <summary>
    /// Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Repository_WebRequest<T> : IRepository_WebRequest<T> {
        private string _lastRawResponse;
        /// <summary>
        /// Last Raw Response
        /// </summary>
        /// <returns></returns>
        public string LastRawResponse() {
            try {
                return _lastRawResponse;
            } catch {
                throw;
            }
    
        }
        /// <summary>
        /// Read Web Request
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual T ReadWebRequest(WebRequestModel input) {
            try {
                var request = System.Net.HttpWebRequest.Create(input.Url);
                request.Method = input.Method;
                request.ContentType = input.ContentType;
                using (var writer = new StreamWriter(request.GetRequestStream())) {
                    writer.Write(input.Json);
                }
                using (var response = request.GetResponse() as HttpWebResponse) {
                    using (var stream = response.GetResponseStream()) {
                        using (var reader = new StreamReader(stream)) {
                            _lastRawResponse = reader.ReadToEnd();
                            return JsonConvert.DeserializeObject<T>(_lastRawResponse);
                        }
                    }
                }
            } catch {
                throw;
            }
        }
    }
}

namespace AsatClientService.Business.Repositories.Base {
    /// <summary>
    /// Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Repository_WebRequest<T> : IRepository_WebRequest<T> {
        private string _lastRawResponse;
        /// <summary>
        /// Last Raw Response
        /// </summary>
        /// <returns></returns>
        public string LastRawResponse() {
            try {
                return _lastRawResponse;
            } catch {
                throw;
            }
    
        }
        /// <summary>
        /// Read Web Request
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual T ReadWebRequest(WebRequestModel input) {
            try {
                var request = System.Net.HttpWebRequest.Create(input.Url);
                request.Method = input.Method;
                request.ContentType = input.ContentType;
                using (var writer = new StreamWriter(request.GetRequestStream())) {
                    writer.Write(input.Json);
                }
                using (var response = request.GetResponse() as HttpWebResponse) {
                    using (var stream = response.GetResponseStream()) {
                        using (var reader = new StreamReader(stream)) {
                            _lastRawResponse = reader.ReadToEnd();
                            return JsonConvert.DeserializeObject<T>(_lastRawResponse);
                        }
                    }
                }
            } catch {
                throw;
            }
        }
    }
}*/