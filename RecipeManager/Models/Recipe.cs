﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Step> Steps { get; set; }
}
