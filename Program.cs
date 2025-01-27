﻿using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowRemoveMenu();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTaskList();
                }
                else if ((Menu)menuSelected == Menu.NotValid)
                {
                    Console.WriteLine("Opción Invalida. Digite otro valor.");
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns> Returns option indicated by user </returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read valueChoosed
            string valueChoosed = Console.ReadLine();
            var i = 0;
            if (int.TryParse(valueChoosed, out i))
            {
                return Convert.ToInt32(valueChoosed);
            }
            return ((int) Menu.NotValid);
        }

        public static void ShowRemoveMenu()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                ListInformation();

                string valueToBeRemoved = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(valueToBeRemoved) - 1;

                if(indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
                        Console.WriteLine("Numero de tarea seleccionado no es valido");
                else
                {
                    if (indexToRemove > -1 && TaskList.Count > 0)
                    {
                        string taskToRemove = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine($"Tarea {taskToRemove} eliminada");
                    }
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error al eliminar la tarea.");
                Console.WriteLine(ex.Message);
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                TaskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error al añadir la tarea.");
                Console.WriteLine(ex.Message);
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            }
            else
            {
                ListInformation();
            }
        }

        public static void ListInformation()
        {
            var indexTask = 1;
            Console.WriteLine("----------------------------------------");
            TaskList.ForEach(task => Console.WriteLine($"{indexTask++} . {task}"));
            Console.WriteLine("----------------------------------------");
        }
    }

    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4,
        NotValid = 5
    }
}
