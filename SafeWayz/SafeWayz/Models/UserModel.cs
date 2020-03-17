using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeWayz.Model
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Profile { get; set; }

        public string FullName { get; set; }
        public string FullSurname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Area { get; set; }
        public string Location { get; set; }
        public int IncidentReport { get; set; }
        public string Incident { get; set; }
        public string IncidentComment { get; set; }
        public string Comment { get; set; }
        public string Report { get; set; }
        public int Point { get; set; }

    }
}
