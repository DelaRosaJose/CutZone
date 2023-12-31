﻿using CommunityToolkit.Mvvm.ComponentModel;
using CutZone.Models.Base;

namespace CutZone.Models
{
    public partial class Article : BaseModel<Article>
    {

        [ObservableProperty]
        bool activo;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string modelo;

        [ObservableProperty]
        int precio;

    }
}

