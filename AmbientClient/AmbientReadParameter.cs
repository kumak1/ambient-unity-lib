using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

namespace AmbientClient
{
    public class AmbientReadParameter
    {
        public DateTime? Date = null;
        public DateTime? Start = null;
        public DateTime? End = null;

        public AmbientReadParameter()
        {
        }

        public NameValueCollection ToCollection()
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (Date != null)
            {
                query.Add("date", Date.ToString());
                return query;
            }

            if (Start != null && End != null)
            {
                query.Add("start", Start.ToString());
                query.Add("end", End.ToString());
                return query;
            }

            return query;
        }

        public NameValueCollection ToCollectionWithKey(string readKey)
        {
            var param = ToCollection();
            param.Add("readKey", readKey);
            return param;
        }
    }
}