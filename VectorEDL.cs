using System;

// DUVIDAS:
// Posso dobrar a capacidade do Vector a cada vez que precisar
// de memoria ou terei que incrementar um a um?
//
// Caso possa dobrar, será necessário também realizar a decre-
// mentar a cada remoção?

class VectorEmptyException : Exception {

}

class Node {
    private object element;
    private Node next;
    private Node prev;

    public Node (object e, Node p, Node n) {
        element = e;
        next = n;
        prev = p;
    }

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
    private Node head, tail;
    private int countSize = 0;

    public VectorLinkedList () {
        Node node = new Node(null, null, null);
        head = new Node(null, null, node);
        tail = new Node(null, node, null);
    }

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
        if (isEmpty()) {
            throw new VectorEmptyException();
        }

        Node new_node = head.getNext();
        for (int i = 0; i < r; i++) {
            new_node = new_node.getNext();
        }

        return new_node;
    }

    public object elemAtRank (int r) {
        if (isEmpty()) {
            throw new VectorEmptyException();
        }
        object o = rank(r).getElement();
        return o;
    }

    public object replaceAtRank (int r, object o) {
        if (isEmpty()) {
            throw new VectorEmptyException();
        }
        Node new_node = rank(r);
        object t = new_node.getElement();
        new_node.setElement(o);
        return t;
    }

    public void insertAtRank (int r, object o) {
        Node new_node;
        if (isEmpty()) {
            new_node = new Node(o, head, tail);
            head.setNext(new_node);
            tail.setPrev(new_node);
        }
        else {
            Node old_node = rank(r);
            new_node = new Node(o, old_node.getPrev(), old_node.getPrev().getNext());
            old_node.getPrev().setNext(new_node);
            old_node.setPrev(new_node);
        }

        countSize++;
    }

    public object removeAtRank (int r) {
        if (isEmpty()) {
            throw new VectorEmptyException ();
        }

        Node new_node = rank(r);
        new_node.getPrev().setNext(new_node.getNext());
        new_node.getNext().setPrev(new_node.getPrev());
        countSize--;
        return new_node.getElement();
    }

    public void printVector () {
        if (isEmpty()) {
            Console.WriteLine("Lista vazia coleguinha!");
        }
        else {
            Node node = head.getNext();
            for (int i = 0; i < countSize; i++) {
                Console.Write($" [{node.getElement()}]");
                node = node.getNext();
            }
            Console.WriteLine();
        }
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
        vector.printVector();
        Console.WriteLine(vector.size()); // 0
        Console.WriteLine(vector.isEmpty()); // true
        vector.insertAtRank(0, 1); // inseriu
        vector.printVector(); // 1
        Console.WriteLine(vector.elemAtRank(0)); // 1
        vector.insertAtRank(1, 2); // inseriu
        vector.printVector(); // 1 2
        Console.WriteLine(vector.replaceAtRank(0, 2)); // substituiu
        vector.printVector(); // 2 2
        Console.WriteLine(vector.removeAtRank(0)); // 2
        vector.printVector(); // 2
    }
}
