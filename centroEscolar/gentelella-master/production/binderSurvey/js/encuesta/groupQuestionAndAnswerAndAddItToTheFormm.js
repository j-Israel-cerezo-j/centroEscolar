function groupQuestionAndAnswerAndAddItToTheForm(event) {

    var form = document.getElementById("form1");

    var id = event.target.attributes.id.value;
    var radioResponse = document.getElementById(id);
    var idQuestion = radioResponse.getAttribute("data-id-question");
    var idResponse = document.getElementById(id).value;


    var intputQuestion = document.createElement("input")
    intputQuestion.type = "hidden";
    intputQuestion.value = idQuestion
    intputQuestion.id = "hiddenQuestion" + idQuestion
    intputQuestion.name = "hiddenQuestion" + idQuestion

    var intputResponse = document.createElement("input")
    intputResponse.type = "hidden";
    intputResponse.value = idResponse;
    intputResponse.id = "hiddenResponseAnswer" + idQuestion;
    intputResponse.name = "hiddenResponseAnswer" + idQuestion

    if (document.getElementById("containerHiddenQuestion" + idQuestion) == undefined) {
        var divContainer = document.createElement("div")
        divContainer.id = "containerHiddenQuestion" + idQuestion;
        form.appendChild(divContainer)

        document.getElementById("containerHiddenQuestion" + idQuestion).appendChild(intputQuestion);
        document.getElementById("containerHiddenQuestion" + idQuestion).appendChild(intputResponse);
    } else {
        document.getElementById("containerHiddenQuestion" + idQuestion).innerHTML = "";

        document.getElementById("containerHiddenQuestion" + idQuestion).appendChild(intputQuestion);
        document.getElementById("containerHiddenQuestion" + idQuestion).appendChild(intputResponse);
    }
}