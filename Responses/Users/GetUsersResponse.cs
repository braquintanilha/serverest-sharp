using System.Collections.Generic;

namespace ServeRestSharp.Responses.Users;

public class GetUsersSuccessfullyResponse
{
        [JsonProperty("quantidade")]
        public int Quantidade { get; set; }

        [JsonProperty("usuarios")]
        public List<User>? Users { get; set; }
    }

    public class User
    {
        [JsonProperty("nome")]
        public string? Nome { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("administrador")]
        public string? Administrador { get; set; }

        [JsonProperty("_id")]
        public string? Id { get; set; }
    }
