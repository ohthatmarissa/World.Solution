using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace World.Models
{
    public class Country
    {
        private string _name;
        private string _countryCode;
        private string _continent;
        private string _region;
        private int _population;

        public Country(string name, string countryCode, string continent, string region, int population)
        {
            _name = name;
            _countryCode = countryCode;
            _continent = continent;
            _region = region;
            _population = population;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetCountryCode()
        {
            return _countryCode;
        }

        public string GetContinent()
        {
            return _continent;
        }

        public string GetRegion()
        {
            return _region;
        }

        public int GetPopulation()
        {
            return _population;
        }

        public static Country GetByName(string _name)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country WHERE name = '"+ _name +"';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            string code;
            string name;
            string continent;
            string region;
            int population;
            
            rdr.Read();
            do
            {
                code = rdr.GetString(0);
                name = rdr.GetString(1);
                continent = rdr.GetString(2);
                region = rdr.GetString(3);
                population = rdr.GetInt32(6);
            } 
            while(rdr.Read());
           
            
            Country country = new Country(name, code, continent, region, population);
            return country;
        }

        public static List<Country> GetAll()
        {
            List<Country> allCountries = new List<Country>{};

            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            while(rdr.Read())
            {   
                string code = rdr.GetString(0);
                string name = rdr.GetString(1);
                string continent = rdr.GetString(2);
                string region = rdr.GetString(3);
                int population = rdr.GetInt32(6);

                Country country = new Country(name, code, continent, region, population);
                allCountries.Add(country);

            }

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }

            return allCountries;
        }


    }
}