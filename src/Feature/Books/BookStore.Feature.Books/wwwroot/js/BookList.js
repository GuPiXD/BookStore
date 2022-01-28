$(document).ready(function () {
  //Amount of Book entries to skip, when fetching the next n Books is skip*n
  var skip = 1;
  //Getting total amount of Book entries
  var amount;
  $.ajax({
    url: "/api/Books",
    type: "GET",
    success: function (data) {
      amount = data;
    }
  });
  //Creating div for book list and various buttons concerning the book list
  var divBook = $("<div>");
  divBook.addClass("book-list");
  //Adding book list div to the document's div.container.body-content
  $("div.container.body-content:first").prepend(divBook);
  //Creating table stencil
  var table = $("<table>");
  table
    .addClass("table table-bordered table-hover")
    .attr("id", "books")
    .append("<thead>")
    .append("<tbody>");
  //Adding head, "Add" button and table stencil to the div.book-list
  divBook
    .append("<h2>Books</h2>")
    .append("<a class = 'btn btn-primary' href = 'Books/New'>Add</a>")
    .append(table);
  //Making ajax request to get list of books. On a successful request the table stencil will be filled with content   
  var books;
  $.ajax({
    url: "/api/Books?skip=0",
    type: "GET",
    success: function (data) {
      books = data;
    },
    complete: function () {
      BuildBookHead();
      BuildBookTable(books);
      if ($("#books tbody tr").length < amount) {
        $(divBook).append("<button class='btn btn-primary js-load'>Load More</button>");
      }
    },
    dataType: "json"
  });

  //Functions responcible for filling the table up with content
  function BuildBookHead() {
    //Adding content to the table head
    var tableRow = $("<tr>");
    tableRow
      .append("<th>ISBN</th>")
      .append("<th>Name</th>")
      .append("<th>Authors</th>")
      .append("<th>Number in Stock</th>")
      .append("<th>Actions</th>")
      .appendTo($("#books thead"));
  }

  function BuildBookTable(input) {
    //Adding content to the table body
    var body = $("#books tbody");
    $.each(input, function (i, book) {
      var tr = $("<tr>");
      tr
        .addClass(book.ISBN)/*function () { return "book-" + i; });*/
        .append("<td width='15%'>" + book.ISBN + "</td>")
        .append("<td width='15%'>" + book.Name + "</td>");
      var tdAuthors = $("<td>");
      var dropdownDiv = $("<div class = 'dropdown'>");
      var authorButton = $("<button class = 'btn dropdown-toggle' type = 'button' data-toggle='dropdown'>Authors <span class='caret'></span></button>");
      var dropdownList = $("<ul class = 'dropdown-menu' aria-labelledby = 'dropdownMenuButton'>");
      $.each(book.Authors, function (i, author) {
        dropdownList.append("<li>" + author.FullName + "</li>");
      });
      dropdownDiv
        .append(authorButton)
        .append(dropdownList)
        .appendTo(tdAuthors);
      tr
        .append(tdAuthors)
        .append("<td>" + book.NumberStock + "</td>");
      var tdButtons = $("<td>");
      tdButtons
        .attr("ISBN", book.ISBN)
        .append("<a class = 'btn btn-primary' href = 'Books/Details?ISBN=" + book.ISBN + "'>View</a><span> </span>")
        .append("<a class = 'btn btn-primary' href = 'Books/Edit?ISBN=" + book.ISBN + "'>Edit</a><span> </span>");
      if (book.IsCheckedout == true) {
        tdButtons.append("<button class='btn btn-primary' disabled>Delete</button><span> </span>")
      }
      else {
        tdButtons.append("<button class='btn btn-primary js-delete' isbn = " + book.ISBN + ">Delete</button><span> </span>")
      }
      if (book.NumberInStock == 0) {
        tdButtons.append("<button class='btn btn-primary' disabled>Check-out</button>")
      }
      else {
        tdButtons.append("<a class='btn btn-primary' href = 'Books/Checkout?ISBN=" + book.ISBN + "'>Check-out</button>")
      }
      tr.append(tdButtons);
      body.append(tr);
    });
  }
  //Handling of the click event of the delete button
  $("tbody").on("click", ".js-delete", function () {
    var button = $(this);
    bootbox.confirm("Do you want to delete this book?", function (result) {
      if (result) {
        $.ajax({
          url: "/books/delete",
          type: "POST",
          data: {
            ISBN: button.attr("isbn")
          },
          success: function () {
            location.reload(true);
          }
        });
      }
    });
  });

  //Handling of the click event of the load more button
  $("div.container.body-content:first").on("click", ".js-load", function () {
    var button = $(this);
    $.ajax({
      url: "/api/Books?skip=" + skip,
      type: "GET",
      success: function (data) {
        books = data;
      },
      complete: function () {
        var rowAmount;
        BuildBookTable(books);
        rowAmount = $("#books tbody tr").length;
        if (rowAmount == amount) {
          $(".js-load").remove();
        }
        skip += 1;
      },
      dataType: "json"
    });

  });
});