﻿
namespace PoliSchool.DAL.Core
{
    public abstract class BaseEntity
    {
        public DateTime CreationDate { get; set; }
        public DateTime? MOdifyDate { get; set; }
        public int CreationUser { get; set; }
        public int? UserMod { get; set; }   
        public int? UserDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }

    }
}