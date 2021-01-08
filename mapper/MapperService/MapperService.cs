using System;
using System.Collections.Generic;
using System.Linq;

namespace MapperService
{
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
            parentList.ForEach(parent => {
                    if(parent.Id == parentId)
                    {
                        parent.children.Add(childId);
                    }
            });
        }

        /// <summary>
        /// Removes all mappings for a valid parent
        /// </summary>
        /// <param name="parent">Parent identifier</param>
        public void RemoveParent(int parentId)
        {
            var parent = parentList.Find(parent => parent.Id == parentId);
            var removeList = parent.children;

            childList.RemoveAll(child => removeList.Any(id => id == child.Id));
            parentList.RemoveAll(parent => parent.Id == parentId);
        }

        /// <summary>
        /// Removes a mapping for a valid child
        /// </summary>
        /// <param name="child">Child identifier</param>
        public void RemoveChild(int childId)
        {
            Console.WriteLine($"Child id: {childId}");
            childList.RemoveAll(child => child.Id == childId);

            parentList.ForEach(parent => {
                parent.children.Remove(childId);
            });
        }

        /// <summary>
        /// Returns all (immediate) children for a given parent.
        /// If there are no mappings for the parent, empty set is returned
        /// </summary>
        /// <param name="parent">Parent identifier</param>
        /// <returns>Children identifiers</returns>
        public IEnumerable<int>GetChildren (int parentId)
        {
            for (int index = 0; index < parentList.Count; index++)
            {
                if(parentList[index].Id == parentId)
                {
                    return parentList[index].children;
                }
            }

            return new HashSet<int>();
        }

        /// <summary>
        /// Returns a parent for a given child.
        /// If there is no mapping for a child, returns 0
        /// </summary>
        /// <param name="child">Child identifier</param>
        /// <returns>Parent identifier</returns>
        public int GetParent(int childId)
        {
            for (int index = 0; index < parentList.Count; index++)
            {
                bool result = parentList[index].children.Any(id => id == childId);
                if(result)
                {
                    return parentList[index].Id;
                }
            }
            return 0;
        }
    }
}

