using DataStructures.LinkedList.SinglyLinkedList;

var node1 = new SinglyLinkedListNode<char>('a');//Dinamikler
var node2 = new SinglyLinkedListNode<char>('b');//Düğüm
var node3 = new SinglyLinkedListNode<char>('c');//Deafult değer null olarak gelecek
var node4 = new SinglyLinkedListNode<char>('d');

node1.Next = node2;//node1 eşittir note2
node2.Next = node3;//Böylece her ifade kendinden sonra gelecek olan diğer ifadeyi işaret eder. Liste oluşturulmuş olur.
node3.Next = node4;

AddFirst<char>('z', ref node1);//Değişen referans değişikliğini görebilmek için Ref£i kullandık.
AddLast<char>('x', node1);

Traverse<char>(node1);//Referans olarak hangi düğüm verilirse o düğümden başlayarak ileriye doğru ilerler.

Console.ReadKey();

static void Traverse<T>(SinglyLinkedListNode<T> Head)//Bağlıliste üzerinde dolaşma
{//Head referans düğümü. Listenin başlangıcıdır.
    if (Head is null)
        throw new ArgumentNullException(nameof(Head));

    var Current = Head;//Mevcut düğüm Head'e eşitlendi.
    while (Current != null)
    {
        Console.WriteLine(Current);
        Current = Current.Next;//Current£ günceller
    }
}
static void AddFirst<T>(T value, ref SinglyLinkedListNode<T> Head) // Başaekleme fonksiyonu  O(1)(Hızlıdır)
{
    if (Head is null)
        throw new ArgumentNullException();

    var newNode = new SinglyLinkedListNode<T>(value);//Eklenecek yeni düğüm.
    newNode.Next = Head;
    Head = newNode;//Head güncelleme
}
static void AddLast<T>(T value, SinglyLinkedListNode<T> Head) // Sona ekleme fonksiyonu O(n)(Yavaştır.)
{
    var newNode = new SinglyLinkedListNode<T>(value);
    var current = Head;
    while (current.Next != null)
    {
        current = current.Next;
    }
    current.Next = newNode;
    return;
}


