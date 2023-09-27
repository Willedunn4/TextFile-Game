using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFile_Game
{
    class DungeonCrawlerGame
    {
        private int playerHP = 50;
        private List<Monster> monsters = new List<Monster>();
        private Room currentRoom;
        private List<Room> rooms = new List<Room>();
        private DoublyNode resultHead;
        private DoublyNode resultTail;

        public void LoadMonsters(string fileName)
        {
            // Read monster stats
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(' ');
                        if (parts.Length == 5)
                        {
                            string type = parts[0];
                            int hp = int.Parse(parts[1]);
                            int mp = int.Parse(parts[2]);
                            int ap = int.Parse(parts[3]);
                            int def = int.Parse(parts[4]);
                            Monster monster = new Monster(type, hp, mp, ap, def);
                            monsters.Add(monster);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error reading file: {e.Message}");
            }
        }

        public void CreateRooms()
        {
            // Create rooms with monsters
            foreach (Monster monster in monsters)
            {
                Room room = new Room(monster);
                rooms.Add(room);
            }

            // Connect rooms
            for (int i = 0; i < rooms.Count - 1; i++)
            {
                rooms[i].NextRoom = rooms[i + 1];
                rooms[i + 1].PrevRoom = rooms[i];
            }

            // Set the current room to the first room
            currentRoom = rooms[0];
        }

        public void RecordResult(string result)
        {
            // Create a new result node and add it to the doubly linked list
            DoublyNode newNode = new DoublyNode(result);
            if (resultHead == null)
            {
                resultHead = newNode;
                resultTail = newNode;
            }
            else
            {
                newNode.Prev = resultTail;
                resultTail.Next = newNode;
                resultTail = newNode;
            }
        }

        public void DisplayResults()
        {
            Console.WriteLine("\nResults:");
            DoublyNode currentNode = resultHead;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Result);
                currentNode = currentNode.Next;
            }
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to the Dungeon Crawler Game!");

            int monstersDefeated = 0;

            while (monstersDefeated < monsters.Count)
            {
                Console.WriteLine($"You have {playerHP} HP left.");
                Console.WriteLine($"You are in a room facing a {currentRoom.Monster.Type} with {currentRoom.Monster.HP} HP.");
                Console.WriteLine("Do you want to (A)ttack, (R)un, or (B)ack?");
                string choice = Console.ReadLine();

                if (choice.ToUpper() == "A")
                {
                    int damage = new Random().Next(10, 21); // Simulate player attack
                    currentRoom.Monster.HP -= damage;
                    Console.WriteLine($"You attacked and dealt {damage} damage!");

                    if (currentRoom.Monster.HP <= 0)
                    {
                        Console.WriteLine($"You defeated the {currentRoom.Monster.Type}!");
                        monstersDefeated++;
                        RecordResult($"You defeated the {currentRoom.Monster.Type}!");
                    }
                }
                else if (choice.ToUpper() == "R")
                {
                    Console.WriteLine("You chose to run away.");
                    rooms.Remove(currentRoom);
                    if (rooms.Count > 0)
                    {
                        int randomRoomIndex = new Random().Next(0, rooms.Count);
                        currentRoom = rooms[randomRoomIndex];
                        RecordResult("You ran away to another room.");
                    }
                }
                else if (choice.ToUpper() == "B")
                {
                    if (currentRoom.PrevRoom != null)
                    {
                        Console.WriteLine("You chose to go back.");
                        currentRoom = currentRoom.PrevRoom;
                        RecordResult("You went back to the previous room.");
                    }
                    else
                    {
                        Console.WriteLine("There's nowhere to go back to.");
                    }
                }
            }

            Console.WriteLine("Congratulations! You defeated all the monsters. You win!");
            RecordResult("Congratulations! You defeated all the monsters. You win!");

            // Display game results
            DisplayResults();
        }
    }
}


