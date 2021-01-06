using System;
using System.Collections.Generic;

namespace MapperService
{
    public class PrimeService
    {
        public bool IsPrime(int candidate)
        {
            if (candidate < 2)
            {
                return false;
            }
            throw new NotImplementedException("Not fully implemented.");
        }
    }

    public class Parent
    {
        public HashSet<int> children = new HashSet<int>();
        public int Id { get; }
        public Parent(int id)
        {
            Id = id;
        }

    }

    public class Child
    {
        public int Id { get; }
        public Child(int id)
        {
            Id = id;
        }

    }

    public class OneToManyMapper : IOneToManyMapper
    {
        public List<Parent> parentList = new List<Parent>();
        public List<Child> childList = new List<Child>();

        /// <summary>
        /// Defines a new mapping between parent and child
        /// </summary>
        /// <param name="parent">Parent identifier</param>
        /// <param name="child">Child identifier</param>
        public void Add(int parentId, int childId)
        {
            Console.WriteLine($"{parentId}-{childId}");
            parentList.ForEach(parent => {
                    if(parent.Id == parentId)
                    {
                        parent.children.Add(childId);
                        Console.WriteLine($"Child Id: {childId} added to Parent Id: {parent.Id}");
                    }
            });
        }
        /// <summary>
        /// Removes all mappings for a valid parent
        /// </summary>
        /// <param name="parent">Parent identifier</param>
        public void RemoveParent(int parent)
        {
            throw new NotImplementedException("Not fully implemented.");
        }
        /// <summary>
        /// Removes a mapping for a valid child
        /// </summary>
        /// <param name="child">Child identifier</param>
        public void RemoveChild(int child)
        {
            throw new NotImplementedException("Not fully implemented.");
        }
        /// <summary>
        /// Returns all (immediate) children for a given parent.
        /// If there are no mappings for the parent, empty set is returned

        /// </summary>
        /// <param name="parent">Parent identifier</param>
        /// <returns>Children identifiers</returns>
        public IEnumerable<int>GetChildren (int parent)
        {
            throw new NotImplementedException("Not fully implemented.");
        }
        /// <summary>
        /// Returns a parent for a given child.
        /// If there is no mapping for a child, returns 0
        /// </summary>
        /// <param name="child">Child identifier</param>
        /// <returns>Parent identifier</returns>
        public int GetParent(int child)
        {
            throw new NotImplementedException("Not fully implemented.");
        }
    }
}

