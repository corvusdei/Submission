using System;

public class Book
{
    // The { get; set; } are known as Getter and Setter methods
    // In e.g. Java they are full methods but C#
    // uses them similarly to access modifiers.
    // Set enables us to change the value of a property
    // Get enables us to get the value (like getting the properties to print them in your ListBooks() method
    // Init means we can set a value when the object is created and not again

    // We haven't covered this in class so I wasn't expecting it but just to answer what it is and why
    // I have suggested a change.
    // We do not have the ability to change the values of any of these properties so we should remove the 'set;'
    // keyword and replace it with 'init' so the only time a books property can be set is during creation.
    // This is not always what we want, setters exist for a reason but in this case it is safer to use init;
    // instead of set.
    public string Title { init; get; }
    public string Author { init; get; }
    public int PublicationYear { init; get; }
}
