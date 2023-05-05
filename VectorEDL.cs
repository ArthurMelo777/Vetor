using System;

// DUVIDAS:
// Posso dobrar a capacidade do Vector a cada vez que precisar
// de memoria ou terei que incrementar um a um?
//
// Caso possa dobrar, será necessário também realizar a decre-
// mentar a cada remoção?

class VectorEmptyException : Exception {

}

class IndexOutOfRangeException : Exception {

}

class Node {
    private object ? element {get; set;}
    private Node ? next {get; set; }
    private Node ? prev {get; set;}
}

class VectorLinkedList {
    private Node ? first, last;
    private int countSize;

    public int size () {
    }

    public int capacity () {
    }

    public bool isEmpty () {
    }

    public object elemAtRank (int r) {
    }

    public void insertAtRank (int r, object o) {
    }

    public object removeAtRank (int r) {
    }
}

class VectorArray {
    private int countSize = 0, n = 1;
    private object[] v = new object[1];

    public void increment () {
        object[] new_vector = new object[n++];
        
        for (int i = 0; i < countSize; i++) {
            new_vector[i] = v[i];
        }

        v = new_vector;
    }

    public void decrement () {
        object[] new_vector = new object[n--];

        for (int i = 0; i < countSize; i++) {
            new_vector[i] = v[i];
        }

        v = new_vector;
    }

    public int size () {
        return countSize;
    }

    public int capacity () {
        return n;
    }

    public bool isEmpty () {
        if (countSize == 0) {
            return true;
        }
        return false;
    }

    public object elemAtRank (int r) {
        if (isEmpty()) {
            throw new VectorEmptyException ();
        }
        if (r >= countSize) {
            throw new IndexOutOfRangeException ();
        }

        return v[r];
    }

    public object replaceAtRank (int r, object o) {
        if (isEmpty()) {
            throw new VectorEmptyException ();
        }
        if (r >= countSize) {
            throw new IndexOutOfRangeException ();
        }

        object t = v[r];
        v[r] = o;
        return t;
    }

    public void insertAtRank (int r, object o) {
        if (r >= n) {
            throw new IndexOutOfRangeException ();
        }

        increment();

        object atual = v[r], proximo;

        for (int i = r; i < countSize; i++) {
            if (r+1 == n) {
                break;
            }
            

            proximo = v[r];
            v[r] = atual;
            atual = proximo;
        }
        

        countSize++;
    }

    public object removeAtRank (int r) {
        if (isEmpty()) {
            throw new VectorEmptyException ();
        }

        decrement();

        object o = v[r];

        countSize--;

        return o;
    }
}

class Program {
    public static void Main (string[] args) {
        VectorArray vector = new VectorArray ();
        vector.insertAtRank(0, '1');
        Console.WriteLine(vector.size());
        Console.WriteLine(vector.capacity());
        vector.insertAtRank(1, 2);
        Console.WriteLine(vector.size());
        Console.WriteLine(vector.capacity());
        vector.insertAtRank(2, 2);
        Console.WriteLine(vector.size());
        Console.WriteLine(vector.capacity());
        vector.removeAtRank(1);
        Console.WriteLine(vector.size());
        Console.WriteLine(vector.capacity());
        vector.removeAtRank(2);
        Console.WriteLine(vector.size());
        Console.WriteLine(vector.capacity());
        vector.insertAtRank(0, 0);
        Console.WriteLine(vector.size());
        Console.WriteLine(vector.capacity());
    }
}