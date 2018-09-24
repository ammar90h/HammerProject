using System;

namespace HammerProject.Database.Entity.Interfaces
{
    /// <summary>
    /// Use this interface in entity where you want to have last modified date field
    /// </summary>
    public interface IHasLastModified
    {
        DateTime? lastModifyDate { get; set; }
    }
}