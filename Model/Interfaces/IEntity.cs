﻿namespace Model.Interfaces
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
