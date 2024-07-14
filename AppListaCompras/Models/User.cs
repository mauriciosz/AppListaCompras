using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaCompras.Models
{
    public partial class User : IRealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("name")]
        public string Name { get; set; } = string.Empty;

        [MapTo("email")]
        public string Email { get; set; } = string.Empty;

        [MapTo("access_code_temp")]
        public string AccessCodeTemp { get; set; } = string.Empty;

        [MapTo("access_code_temp_create_at")]
        public DateTimeOffset AccessCodeTempCreateAt { get; set; }

        [MapTo("create_at")]
        public DateTimeOffset CreateAt { get; set; }
    }
}
