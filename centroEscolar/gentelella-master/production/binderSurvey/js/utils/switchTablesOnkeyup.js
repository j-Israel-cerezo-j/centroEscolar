function SwitchTableOnkeyup(catalogo, json, jsonOnkeyp = true) {
    switch (catalogo) {        
        case 'questions':
            buildQuestions(json, jsonOnkeyp);
            break;
        case 'questionsCategory':
            buildTableQuestionsCategory(json, jsonOnkeyp);
            break;
        case 'questionsAnswer':
            buildTableQuestionsAnswer(json, jsonOnkeyp);
            break;
    }
}