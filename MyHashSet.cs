using System;

public class MyHashSet<E> where E : IComparable<E>
{
    private readonly MyHashMap<E, object> map = new MyHashMap<E, object>();

    public MyHashSet() { }

    public MyHashSet(E[] array)
    {
        foreach (var element in array) map.Put(element, default);
    }

    public MyHashSet(int initialCapacity)
    {
        map = new MyHashMap<E, object>(initialCapacity);
    }
    public MyHashSet(uint initialCapacity, float loadFactor)
    {
        map = new MyHashMap<E, object>(initialCapacity, loadFactor);
    }

    public void Add(E element) => map.Put(element, default);

    public void AddAll(E[] array)
    {
        foreach (var element in array) map.Put(element, default);
    }

    public void Clear() => map.Clear();

    public bool Contains(E element) => map.ContainsKey(element);

    public bool ContainsAll(E[] array)
    {
        foreach (var element in array)
        {
            if (!map.ContainsKey(element)) return false;
        }

        return true;
    }

    public bool Remove(E element) => map.Remove(element);

    public void RemoveAll(E[] array)
    {
        foreach (var element in array) map.Remove(element);
    }

    public void RetainAll(E[] array)
    {
        foreach (var element in map.KeySet())
        {
            if (Array.IndexOf(array, element) == -1) map.Remove(element);
        }
    }

    public int Size() => map.Size();

    public E[] ToArray()
    {
        E[] array = map.KeySet().ToArray();
        Array.Sort(array, (a, b) => a.CompareTo(b));
        return array;
    }

    public E[] ToArray(ref E[] array)
    {
        E[] keys = ToArray();

        if (array == null) return keys;

        for (int index = 0; index < keys.Length; index++) array[index] = keys[index];

        return array;
    }

    public E First()
    {
        if (Size() == 0) return default;
        E[] keys = ToArray();
        return keys[0];
    }

    public E Last()
    {
        if (Size() == 0) return default;
        E[] keys = ToArray();
        return keys[keys.Length - 1];
    }

    public MyHashSet<E> SubSet(E fromElement, E toElement)
    {
        MyHashSet<E> hashSet = new MyHashSet<E>();

        foreach (var element in map.KeySet())
        {
            if (element.CompareTo(fromElement) >= 0 && element.CompareTo(toElement) < 0)
            {
                hashSet.Add(element);
            }
        }

        return hashSet;
    }

    public MyHashSet<E> HeadSet(E toElement)
    {
        MyHashSet<E> hashSet = new MyHashSet<E>();

        foreach (var element in map.KeySet())
        {
            if (element.CompareTo(toElement) < 0)
            {
                hashSet.Add(element);
            }
        }

        return hashSet;
    }

    public MyHashSet<E> TailSet(E fromElement)
    {
        MyHashSet<E> hashSet = new MyHashSet<E>();

        foreach (var element in map.KeySet())
        {
            if (element.CompareTo(fromElement) >= 0)
            {
                hashSet.Add(element);
            }
        }

        return hashSet;
    }
}
