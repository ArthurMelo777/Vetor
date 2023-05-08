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
    private object element = new object();
    private Node next = new Node();
    private Node prev = new Node();

    public void setElement (object e) {
        element = e;
    }

    public object getElement () {
        return element;
    }

    public void setPrev (Node p) {
        prev = p;
    }

    public Node getPrev () {
        return prev;
    }

    public void setNext (Node n) {
        next = n;
    }

    public Node getNext () {
        return next;
    }
}

class VectorLinkedList {
    private Node first = new Node(), last = new Node();
    private int countSize = 0;

    public int size () {
        return countSize;
    }

    public bool isEmpty () {
        if (countSize == 0) {
            return true;
        }
        return false;
    }

    public Node rank (int r) {
        Node n;
        if (r <= countSize/2) {
            n = first;
            for (int i = 0; i < r; i++) {
                n = n.getNext();
            }
        }
        else {
            n = last;
            for (int i = countSize; i > r; i--) {
                n = n.getPrev();
            }
        }
        
        return n;
    }

    public object elemAtRank (int r) {
        object o = rank(r).getElement();
        return o;
    }

    public void insertAtRank (int r, object o) {
        Node new_node = new Node();
        new_node.setElement(o);
        if (countSize == 0) {
        }
        else if ((r >= countSize) && (r != 0)) {
            throw new IndexOutOfRangeException ();
        }
        else {
            Node next = rank(r);
            Node prev = next.getPrev();
            new_node.setPrev(prev);
            new_node.setNext(next);
            prev.setNext(new_node);
            next.setPrev(new_node);
        }
        
        if (r == 0) {
            first = new_node;
        }
        if (r == countSize-1) {
            last = new_node;
        }

        countSize++;
    }

    public object removeAtRank (int r) {
        if (isEmpty()) {
            throw new VectorEmptyException ();
        }

        Node new_node = rank(r);
        Node prev = new_node.getPrev();
        Node next = new_node.getNext();
        object o = new_node.getElement();
        prev.setNext(next);
        next.setPrev(prev);
        
        if (r == 0) {
            first = next;
        }
        if (r == countSize-1) {
            last = prev;
        }

        countSize--;
        return o;
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
        VectorLinkedList vector = new VectorLinkedList();

        vector.insertAtRank(0, 1);
        Console.WriteLine(vector.size());
        vector.insertAtRank(1, 2);
        Console.WriteLine(vector.size());
        vector.insertAtRank(2, 2);
        Console.WriteLine(vector.size());
        vector.removeAtRank(1);
        Console.WriteLine(vector.size());
        vector.removeAtRank(2);
        Console.WriteLine(vector.size());
        vector.insertAtRank(0, 0);
        Console.WriteLine(vector.size());
    }
}
