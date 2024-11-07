# SarhanM_temaCLI

## Răspunsuri

---

1. **Ce este un viewport?**  
   Viewport-ul este zona dreptunghiulară a ferestrei unde OpenGL desenează scena. Se poate ajusta pentru a controla dimensiunea și poziția conținutului vizibil pe ecran.

---

2. **Ce reprezintă conceptul de FPS (frames per second)?**  
   FPS arată câte cadre sunt randate pe secundă, indicând performanța randării. Un FPS mai mare de obicei oferă o animație mai fluentă.

---

3. **Când este rulată metoda `OnUpdateFrame()`?**  
   Această metodă este apelată la o rată specificată, de obicei sincronizată cu rata de reîmprospătare a ecranului. Este folosită pentru actualizările logice, cum ar fi pozițiile obiectelor sau fizica.

---

4. **Ce este modul imediat de randare?**  
   Modul imediat de randare este o metodă veche în OpenGL unde fiecare punct (vertex) este specificat direct în codul de desenare. Este mai lentă, iar metodele moderne de randare sunt mai eficiente.

---

5. **Care este ultima versiune de OpenGL care acceptă modul imediat?**  
   OpenGL 3.0 a fost ultima versiune care a acceptat modul imediat, deși a fost ulterior înlocuit de shader-ele programabile.

---

6. **Când este rulată metoda `OnRenderFrame()`?**  
   Această metodă este apelată la fiecare cadru și este responsabilă pentru randarea scenei pe ecran.

---

7. **De ce este nevoie ca metoda `OnResize()` să fie executată cel puțin o dată?**  
   Această metodă ajustează viewport-ul pentru a se potrivi cu dimensiunea ferestrei, asigurând astfel ca scena randată să se adapteze corect la mărimea ferestrei.

---

8. **Ce reprezintă parametrii metodei `CreatePerspectiveFieldOfView()` și care este domeniul de valori pentru aceștia?**  
   Această funcție primește de obicei un unghi de vedere, raportul de aspect și planurile de decupare (near/far). Unghiul de vedere variază de obicei între 30 și 120 de grade.

---
