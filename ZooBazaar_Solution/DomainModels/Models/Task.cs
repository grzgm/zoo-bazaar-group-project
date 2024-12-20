﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_DomainModels.Models
{

    public enum TASKNAME
    {
        Cleaning, 
        Feeding, 
        VetCheckup, 
        SpecialCare, 
        None,
        AddSupplies,
        PlayTime,
        GuestTour,
        WaterRefill,
        TicketSale
    }
    public class Task
    {
        private int _id;
        private TASKNAME _name;
        private Animal? _animal;
        private Habitat _habitat;
        private Zone _zone;

        public Task(int id, string name, Animal animal, Habitat habitat, Zone zone)
        {
            _id = id;
            _name = Enum.Parse<TASKNAME>(name, true);
            if(animal != null)
            {
                _animal = animal;
            }
            _habitat = habitat;
            _zone = zone;
        }
        public Task(TaskDTO taskDTO)
        {
            this._id = taskDTO.TaskID;
            this._name = Enum.Parse<TASKNAME>(taskDTO.Name, true);
            if(taskDTO.AnimalDTO != null)
            {
                this._animal = new Animal(taskDTO.AnimalDTO);
            }
            this._habitat = new Habitat(taskDTO.HabitatDTO);
            this._zone = new Zone(taskDTO.HabitatDTO.ZoneDTO);
        }

        public Animal? animal { get { return _animal != null ? _animal : null; } }
        public string taskName { get { return _name.ToString(); } }
        public string habitat { get { return _habitat.ToString(); } }
        public string zone { get { return _zone.ToString(); } }
        public int ID { get { return _id; } }

    }
}
