Reflektionsrapport 
 

Utmaningar: Jag stötte på en del utmaningar under denna uppgiften så jag tyckte det var svårt att komma in i TDD tänket och hela testningen egentligen. Men denna uppgiften fick man sitta och klura med så jag kände att jag lärde mig mycket utav den. Jag hade även svårt att förstå i början att jag vill få två sidor utav att testa en viss grej. Båda ska bli godkända men att man manipulerar ena testet med Assert.IsFalse och den andra Asser.IsTrue.  

  

Lärdomar från TDD: Genom att använda TDD metoden har jag märkt hur skönt det är att lättare kunna hitta små buggar och fel i koden i tidigare skede. Eftersom man kör testerna med jämna mellanrum så är det mycket lättare att kunna stanna upp och se vart buggen/problemet finns. Annars har jag varit med om att man skapar ett fel som bara byggs på och längre fram i projektet är det mycket mer komplext att kunna gå in och ändra.  

  

Överväganden och antaganden: Under utvecklingen av projektet valde jag att använda ett enkelt designmönster så skapade två huvudkomponenter. En User-klass och en RegistrationService-klass. Dessa två komponenter var ansvariga för att hantera användarinformation och utföra registreringsfunktionaliteten. 

För att testa funktionaliteten och säkerställa att min kod fungerade som förväntat skapade jag ett separat MSTest-testprojekt inom samma lösning. Detta gjorde det möjligt för mig att enkelt referera till och köra mina tester för att testa min kod. 

  

Framtida förbättringar: 

I framtiden skulle jag vilja utveckla mina tester genom att utforska column testing. Genom att använda denna metod kan jag testa olika kombinationer av inmatningsvärden mer effektivt och därmed öka täckningen av mina tester. Tänkte om jag orkade pyssla med det i denna uppgiften men jag kände att jag inte hade tid och ork för det. 
