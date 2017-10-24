using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageV2.Models
{
        public class Garage<T> : IEnumerable<T> where T : ParkedVehicle
        {

            private T[] vehicles;

            public int Capacity { get; set; }

            public Garage(int capacity)
            {
                if (capacity < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Capacity can't be negative");
                }
                Capacity = capacity;

                vehicles = new T[Capacity];
                //PopulateArrayForTest();
            }

            internal bool AddVehicle(T v)
            {
                for (int i = 0; i < vehicles.Length; i++)
                {
                    if (vehicles[i] == null)
                    {
                        vehicles[i] = v;
                        break;
                    }
                }
                return true;
            }

            internal bool RemoveVehicle(T v)
            {
                for (int i = 0; i <= vehicles.Length; i++)
                {
                    if (vehicles[i] == v)
                    {
                        Console.WriteLine(vehicles[i].ToString());
                        vehicles[i] = null;
                        break;
                    }
                }
                return true;
            }

            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < Capacity; i++)
                {
                    if (vehicles[i] != null)
                        yield return vehicles[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }

