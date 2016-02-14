$(function ()
{
    /*************************************************************************************/
    //Скрипты для поиска по названию документа
    var ajaxFormSubmit = function()
    {
        
        var form = $(this);
        var options = {
            url: form.attr("action"),
            type: form.attr("method"),
            data:form.serialize()
        }

        $.ajax(options).done(function(data)
        {
            var target = $(form.attr("data-dr-target"));
            var newHtml = $(data);
            target.replaceWith(newHtml);             
        });
        return false;
    }

    var submitAutocompleteForm = function(event, ui)
    {
        var input = $(this);

        input.val(ui.item.label);
        var form = input.parents("form:first");
        form.submit();
    }

    var createAutocomplete = function()
    {
        var input = $(this);             
        var options = {
            source: input.attr("data-dr-autocomplete"),
            select : submitAutocompleteForm
        }
       
        input.autocomplete(options);
    }

    $("form[data-dr-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-dr-autocomplete]").each(createAutocomplete);
   
    //Скрипты для поиска по названию документа
    /*************************************************************************************/
   

    //var fileOpeningSimulation = function ()
    //{
    //    var doc = $(this).parents(".panel").find("h3").text();

    //    alert("Открываю " + doc);


    //}

    //$("button[data-dr-opendoc]").click(fileOpeningSimulation)

   
    function createTagIt()
    {

        var input = $(this);
        
        var options = {
            placeholderText: "Введите метку",
            autocomplete: {
                source: input.attr("data-dr-available-tags"),
                delay: 0,
                minLength: 1
            },
            showAutocompleteOnFocus: true
        }
        input.tagit(options);
        
    }

    $("ul[data-dr-contol='tagit']").each(createTagIt)
  
    function createDatepicker ()
    {
        $('#dateTimePicker').datepicker();
        
       
    };
    createDatepicker();


    /*************************************************************************************/
    //Скрипты для сортировки по атрибутам документа

    //Правила сортировки
    //#######################################################
    var compareDocsDatesAsc = function (firstDoc, secondDoc)
    {
        return firstDoc.date >= secondDoc.date;
    }
    
    var compareDocsDatesDesc = function (firstDoc, secondDoc)
    {
        return firstDoc.date <= secondDoc.date;
    }




    var compareDocsAuthorAsc = function (firstDoc, secondDoc)
    {
        return firstDoc.author >= secondDoc.author;
    }

    var compareDocsAuthorDesc = function (firstDoc, secondDoc)
    {
        return firstDoc.author <= secondDoc.author;
    }
   



    var compareDocsNameAsc = function (firstDoc, secondDoc)
    {
        return firstDoc.name >= secondDoc.name;
    }

    var compareDocsNameDesc = function (firstDoc, secondDoc)
    {
        return firstDoc.name <= secondDoc.name;
    }
    //#######################################################


    var docsCollection = function ()
    {
        var docs = [];
        var d = $(".wrapper").find(".panel.panel-success").each(function (index)
        {
            docs[docs.length] = {
                html: $(this).html(),
                author: $(this).find("[data-dr-author]").attr("data-dr-author"),

                date: new Date($(this).find("em").attr("data-dr-date-year"), 
                                $(this).find("em").attr("data-dr-date-month"),
                                $(this).find("em").attr("data-dr-date-day" )),

                name : $(this).find("h3").text()   /**/ 
            }
            
        });
        ///alert("docsCollection");
        return docs;
    }


    var sortDocs = function (docsCollection, sortFunction)
    {
        
        var docs = docsCollection;
        
        docs.sort(sortFunction);
        var newHtml = $(".wrapper").empty();
        for (var i = 0; i < docs.length; i++)
        {
            newHtml.append('<div class="panel panel-success">' + docs[i].html + '</div>');
        }        
    }


    var sortButtonClick = function ()
    {
        var button = $(this);
        var sortAction = button.attr("data-dr-sort-type");
        //**********************************************
        //По уму здесь должно быть решение в одну строчку, 
        //с делегатами в качестве параметров в функции "sortDocs", 
        //но как указать что функция должна принимать делегаты я не нашел
        //**********************************************
        switch (sortAction) 
        {
            case "compareDocsDatesAsc" :
                {
                    sortDocs(docsCollection(), compareDocsDatesAsc);
                    break;
                }
            case "compareDocsDatesDesc" :
                {
                    sortDocs(docsCollection(), compareDocsDatesDesc);
                    break;
                }



            case "compareDocsAuthorAsc":
                {
                    sortDocs(docsCollection(), compareDocsAuthorAsc);
                    break;
                }
            case "compareDocsAuthorDesc":
                {
                    sortDocs(docsCollection(), compareDocsAuthorDesc);
                    break;
                }


            case "compareDocsNameAsc":
                {
                    sortDocs(docsCollection(), compareDocsNameAsc);
                    break;
                }
            case "compareDocsNameDesc":
                {
                    sortDocs(docsCollection(), compareDocsNameDesc);
                    break;
                }



            default:
                {alert("Неверные параметры сортировки");}           
        }
      
        
    }


    $("button[data-dr-control='sort-button']").click(sortButtonClick);
    //$("#test").click(sortButtonClick);


    //Скрипты для сортировки по атрибутам документа
    /*************************************************************************************/
});                             