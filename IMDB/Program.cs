﻿using System;
using IMDB.Service;
using IMDB.Domain;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;
using IMDB.Repository;

namespace IMDB

{
    class Program
    {
        static void Main(string[] args) 
        {
            var service=new IMDBService(new IMDBRepository());
            service.Add(2009, "The Avatar 1", "A good sci-fi movie", new Person("James Cameron", DateOnly.Parse("12-11-2000")), new List<Person>() { new Person("1James Cameron", DateOnly.Parse("12-11-2000")), new Person("2James Cameron", DateOnly.Parse("12-11-2000")) });
            var userChoice = 0;
            string name, plot,actorsIndex;
            int yearOfRelease,producerIndex,movieIndex;
            DateOnly dateOfBirth;
            var listOfString=new List<string>();
            Console.WriteLine("1) List Movies\r\n2) Add Movie\r\n3) Add Actor\r\n4) Add Producer\r\n5) Delete Movie\r\n6) Exit\r\n");
            while (userChoice !=6) 
            {
                Console.WriteLine("What do you want to do?");
                userChoice = int.Parse(Console.ReadLine());
                switch(userChoice)
                {
                    case 1:
                        Console.WriteLine(service.ListMovies());
                        break;
                    case 2:
                        Console.Write("Name: "); 
                        name=Console.ReadLine();
                        Console.Write("Year of release: ");
                        yearOfRelease=int.Parse(Console.ReadLine());
                        Console.Write("Plot: ");
                        plot = Console.ReadLine();
                        Console.Write("Choose Actor(s): ");
                        listOfString=service.ShowListOfActorsOrProducers(true).Select(a => a.Name).ToList();
                        for (var index = 0; index<listOfString.Count();index=index+1 )
                        {
                            Console.Write($"{index+1}. {listOfString[index]} ");
                        }
                        Console.WriteLine();
                        actorsIndex=Console.ReadLine();
                        Console.Write("Choose Producer: ");
                        listOfString = service.ShowListOfActorsOrProducers(false).Select(a => a.Name).ToList();
                        for (var index = 0; index < listOfString.Count(); index = index + 1)
                        {
                            Console.Write($"{index + 1}. {listOfString[index]} ");
                        }
                        Console.WriteLine();
                        producerIndex = int.Parse(Console.ReadLine());
                        service.Add(yearOfRelease, name, plot, service.ChosenProducer(producerIndex), service.ChosenActors(actorsIndex));
                        break;
                    case 3:
                        Console.Write("Name: ");
                        name=Console.ReadLine();
                        Console.Write("DOB: ");
                        dateOfBirth = DateOnly.Parse(Console.ReadLine());
                        service.AddActorOrProducer(name, dateOfBirth, true);
                        break;
                    case 4:
                        Console.Write("Name: ");
                        name = Console.ReadLine();
                        Console.Write("DOB: ");
                        dateOfBirth = DateOnly.Parse(Console.ReadLine());
                        service.AddActorOrProducer(name, dateOfBirth, false);
                        break;
                    case 5:
                        listOfString = service.Get().Select(a => a.Name).ToList();
                        for (var index = 0; index < listOfString.Count(); index = index + 1)
                        {
                            Console.Write($"{index + 1}. {listOfString[index]} ");
                        }
                        Console.WriteLine();
                        movieIndex=int.Parse(Console.ReadLine());
                        service.DeleteMovie(movieIndex);
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        } 
    }
} 