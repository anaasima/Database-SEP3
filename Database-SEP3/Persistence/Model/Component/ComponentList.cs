using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Database_SEP3.Persistence.Model.Component
{
    public class ComponentList
    {
        [JsonPropertyName("components")]
        public IList<ComponentModel> Components { get; set; }


        public ComponentList()
        {
            Components = new List<ComponentModel>();
        }

        public ComponentModel GetComponent(int index)
        {
            return Components[index];
        }

        public void AddComponent(ComponentModel component)
        {
            Components.Add(component);
        }

        public void RemoveComponent(ComponentModel component)
        {
            Components.Remove(component);
        }

        public int Size()
        {
            return Components.Count;
        }
        
        public override string ToString()
        {
            string s = "";
            foreach (var VARIABLE in Components)
            {
                s += VARIABLE.ToString();
            }

            return s;
        }
    }
}