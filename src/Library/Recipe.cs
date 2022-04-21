//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"El costo total es: {GetProductionCost()}");
        } 
        public double GetProductionCost()
        {
                //double insumos=this.unitCost;
                //double equipm = this.hourlyCost;
                //total = double insumos + double equipm;
                double insumo = 0;
                double cantidadproducto = 0;
                double equipamiento = 0;
                double tiempo = 0;
                double total = 0;
                foreach (Step step in steps)
                {
                    insumo += step.Quantity;
                    cantidadproducto += step.Input.UnitCost;
                    equipamiento += step.Equipment.HourlyCost;
                    tiempo += step.Time;
                    total += (insumo*cantidadproducto + equipamiento)/tiempo;
                }
                return total;

            }   
    }   
}