# SarhanM_temaCLI

## Răspunsuri (Lab 02)

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

### Răspunsuri (Lab 03)

---

1. **Care este ordinea de desenare a vertexurilor pentru aceste metode (orar sau anti-orar)?**  
   Ordinea de desenare a vertexurilor în OpenGL este **anti-orară** (counter-clockwise). Această ordine este folosită pentru a stabili fața "din față" a unui obiect.

---

2. **Ce este anti-aliasing?**  
   Anti-aliasing este o tehnică folosită pentru a **netezi marginile obiectelor** randate, astfel încât liniile diagonale și curbele să pară mai puțin „dințate”.

---

3. **Care este efectul rulării comenzii `GL.LineWidth(float)`? Dar pentru `GL.PointSize(float)`?**  
   - `GL.LineWidth(float)` setează **grosimea liniilor** desenate.
   - `GL.PointSize(float)` setează **dimensiunea punctelor** desenate.  
   Ambele funcții pot fi folosite **atât în interiorul, cât și în afara** unei zone `GL.Begin()`.

---

4. **Care este efectul utilizării directivei `LineLoop`?**  
   `LineLoop` conectează **ultimul vertex înapoi la primul**, formând un **circuit închis**.

---

5. **Care este efectul utilizării directivei `LineStrip`?**  
   `LineStrip` conectează fiecare vertex la următorul, dar **nu închide bucla** la ultimul vertex.

---

6. **Care este efectul utilizării directivei `TriangleFan`?**  
   `TriangleFan` creează o **serie de triunghiuri** care împart un vertex central. Fiecare nou triunghi folosește următorul vertex și primul vertex al fanului.

---

7. **Care este efectul utilizării directivei `TriangleStrip`?**  
   `TriangleStrip` creează o **bandă de triunghiuri conectate**, unde fiecare nou vertex formează un triunghi cu cele două vertexuri precedente.

---

8. **Ce reprezintă un gradient de culoare?**  
   Un gradient de culoare este o **tranziție lină între două sau mai multe culori**. În OpenGL, acesta se obține prin specificarea de culori diferite pentru fiecare vertex, iar OpenGL le va combina automat între vertexuri.

---

9. **De ce este importantă utilizarea de culori diferite (gradient) în desenarea obiectelor 3D?**  
   Utilizarea de culori diferite ajută la **evidențierea detaliilor și adâncimii obiectelor**. Creează un efect vizual mai realist și face obiectele să pară mai „3D”.

---
