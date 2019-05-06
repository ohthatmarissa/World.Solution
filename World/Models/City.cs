using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace World.Models
{
    public class City
    {
        private string _name;
        private string _countryCode;
        private string _district;
        private int _population;
        private int _id;


        @"SELECT * FROM city WHERE name LIKE _variable"


        public City(string name, string countryCode, string district, int population, int id)
        {
            _name = name;
            _countryCode = countryCode;
            _district = district;
            _population = population;
            _id = id;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetCountryCode()
        {
            return _countryCode;
        }

        public string GetDistrict()
        {
            return _district;
        }

        public int GetPopulation()
        {
            return _population;
        }

        public int GetId()
        {
            return _id;
        }
        
        public static City GetByName(string _name)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM city WHERE name = '"+ _name +"';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            string code;
            string name;
            string district;
            int id;
            int population;
            
            rdr.Read();
            do
            {
                code = rdr.GetString(2);
                name = rdr.GetString(1);
                district = rdr.GetString(3);
                id = rdr.GetInt32(0);
                population = rdr.GetInt32(4);
            } 
            while(rdr.Read());
           
            
            City city = new City(name, code, district, population, id);
            return city;
        }
        public static List<City> GetAll()
        {
            List<City> allCities = new List<City>{};

            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM city ORDER BY name ASC;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            while(rdr.Read())
            {   
                int id = rdr.GetInt32(0);
                string code = rdr.GetString(2);
                string name = rdr.GetString(1);
                string district = rdr.GetString(3);
                int population = rdr.GetInt32(4);

                City city = new City(name, code, district, population, id);
                allCities.Add(city);

            }

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }

            return allCities;
        }
    }
}