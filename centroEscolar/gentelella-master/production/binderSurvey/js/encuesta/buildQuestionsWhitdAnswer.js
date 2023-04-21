async  function  buildQuestionsWhitdAnswer(json) {
    document.getElementById("containerQuestions").innerHTML = "";      
    
    
    for (var i = 0; i < json.length; i++) {

        const jsonQuestionAnswer = await fetch("Handlers/questionAnswersHandler.aspx?idQuestions=" + json[i].id);
        jsonQuestionAnswer.json()
            .then((resp) => {
                build(json, resp.data.questionsAnswer, i-1);
            })
    }
}

function build(jsonQestion, respQuestionAnswer, i) {
    console.log(i)
    let html= `<div class="row preguntas">
                    <div class="col-12 col-md-12 col-lg-12 col-xs-12">
                        <div>
                            <h3>${jsonQestion[i].descripcion}</h3>
                        </div>
                        <fieldset id="question${jsonQestion[i].id}">`
                for (var j = 0; j < respQuestionAnswer.length; j++) {

                    html +=  `                            
                            <div class="form-check opciones">                                
                                    <input class="form-check-input" id="radio${jsonQestion[i].id}${respQuestionAnswer[j].idResponse}" data-id-question="${jsonQestion[i].id}" value="${respQuestionAnswer[j].idResponse}" type="radio" name="question${jsonQestion[i].id}" onchange="groupQuestionAndAnswerAndAddItToTheForm(event)"  />
                                    <label class="form-check-label" for="flexRadioDefault1">
                                        ${respQuestionAnswer[j].descripcion}
                                    </label>                                
                            </div>`
                }
          
    html += `
                    </fieldset>
                </div>
            </div> `
    var prevInnerHtml = document.getElementById("containerQuestions").innerHTML;
    html += prevInnerHtml;
    document.getElementById("containerQuestions").innerHTML = html
}