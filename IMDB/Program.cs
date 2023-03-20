using System;
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
            var userChoice = 0;
            string name, plot,actorsIndex;
            int yearOfRelease,producerIndex,movieIndex;
            DateOnly dateOfBirth;
            var listOfString=new List<string>();
            Console.WriteLine("1) List Movies\r\n2) Add Movie\r\n3) Add Actor\r\n4) Add Producer\r\n5) Delete Movie\r\n6) Exit\r\n");
            while (userChoice !=6) 
            {
                Console.WriteLine("\nWhat do you want to do?");

                userChoice = int.Parse(Console.ReadLine());
                switch(userChoice)
                {
                    case 1:
                        if (string.IsNullOrWhiteSpace(service.ListMovies()))
                            Console.WriteLine("Empty repository");
                        else
                            Console.WriteLine(service.ListMovies());
                        break;
                    case 2:
                        try
                        {
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
                        }
                        catch (Exception ex) 
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        try
                        {
                            Console.Write("Name: ");
                            name = Console.ReadLine();
                            Console.Write("DOB: ");
                            dateOfBirth = DateOnly.Parse(Console.ReadLine());
                            service.AddActorOrProducer(name, dateOfBirth, true);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 4:
                        try
                        {
                            Console.Write("Name: ");
                            name = Console.ReadLine();
                            Console.Write("DOB: ");
                            dateOfBirth = DateOnly.Parse(Console.ReadLine());
                            service.AddActorOrProducer(name, dateOfBirth, false);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 5:
                        listOfString = service.Get().Select(a => a.Name).ToList();
                        Console.Write("Choose a movie to delete: ");
                        for (var index = 0; index < listOfString.Count(); index = index + 1)
                        {
                            Console.Write($"{index + 1}. {listOfString[index]} ");
                        }
                        Console.WriteLine();
                        try
                        {
                            movieIndex=int.Parse(Console.ReadLine());
                            service.DeleteMovie(movieIndex);
                        }
                        catch(Exception ex) 
                        {
                            Console.WriteLine(ex.Message);
                        }
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