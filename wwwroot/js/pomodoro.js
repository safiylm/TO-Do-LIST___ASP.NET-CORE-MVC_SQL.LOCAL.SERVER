const affichageTravail = document.querySelector('.affichageT');
const affichagePause = document.querySelector('.affichageP');
const btnGo = document.querySelector('.b1');
const btnPause = document.querySelector('.b2');
const btnReset = document.querySelector('.b3');
const cycles = document.querySelector('h2');

let checkInterval = false;
let tempsInitial = 1800;
let tempsDeRepos = 300;
let pause = false;
let nbDeCycles = 0;
cycles.innerText = `Nombre de cycles ${nbDeCycles}`;

/*`${Math.trunc(tempsInitial/60)} affiche les minutes */
/** ${(tempsInitial % 60 < 10) ? `0${tempsInitial % 60}`
 * si c'est inf a 10 on affiche 0 et le nombre (secondes)
 * sinon on affiche  ? ` tempsInitial % 60}`
 */
/*on initialise les boutons  */
affichageTravail.innerText = `${Math.trunc(tempsInitial / 60)} : ${(tempsInitial % 60 < 10) ? `0${tempsInitial % 60}` : tempsInitial % 60}`;
affichagePause.innerText = `${Math.trunc(tempsDeRepos / 60)} : ${(tempsDeRepos % 60 < 10) ? `0${tempsDeRepos % 60}` : tempsDeRepos % 60}`;

btnGo.addEventListener('click', () => {

    //empeche de spammer (appuier le bouton demarrer plusieurs fois)
    if (checkInterval === false) {

        checkInterval = true;

        //pour qu'il commence des que le bouton a ete clique sinon commence un peu tard 
        tempsInitial--;
        affichageTravail.innerText = `${Math.trunc(tempsInitial / 60)} : ${(tempsInitial % 60 < 10) ? `0${tempsInitial % 60}` : tempsInitial % 60}`;

        //setIntercvalle ca se tepete toutes les 1000 miliseconde(second parametre) 
        let timer = setInterval(() => {

            if (pause === false && tempsInitial > 0) {
                tempsInitial--;
                affichageTravail.innerText = `${Math.trunc(tempsInitial / 60)} : ${(tempsInitial % 60 < 10) ? `0${tempsInitial % 60}` : tempsInitial % 60}`;
            }
            else if (pause === false && tempsDeRepos === 0 && tempsInitial === 0) {
                tempsInitial = 1800;
                tempsDeRepos = 300;
                nbDeCycles++;
                cycles.innerText = `Nombre de cycles ${nbDeCycles}`;
                affichageTravail.innerText = `${Math.trunc(tempsInitial / 60)} : ${(tempsInitial % 60 < 10) ? `0${tempsInitial % 60}` : tempsInitial % 60}`;
                affichagePause.innerText = `${Math.trunc(tempsDeRepos / 60)} : ${(tempsDeRepos % 60 < 10) ? `0${tempsDeRepos % 60}` : tempsDeRepos % 60}`;
            }
            else if (pause === false && tempsInitial === 0) {
                tempsDeRepos--;
                affichagePause.innerText = `${Math.trunc(tempsDeRepos / 60)} : ${(tempsDeRepos % 60 < 10) ? `0${tempsDeRepos % 60}` : tempsDeRepos % 60}`;

            }


        }, 1000)

        // Reset
        btnReset.addEventListener('click', () => {
            clearInterval(timer);
            checkInterval = false;
            tempsInitial = 1800;
            tempsDeRepos = 300;
            affichageTravail.innerText = `${Math.trunc(tempsInitial / 60)} : ${(tempsInitial % 60 < 10) ? `0${tempsInitial % 60}` : tempsInitial % 60}`;
            affichagePause.innerText = `${Math.trunc(tempsDeRepos / 60)} : ${(tempsDeRepos % 60 < 10) ? `0${tempsDeRepos % 60}` : tempsDeRepos % 60}`;
        })


    } else {
        return;
    }





})

btnPause.addEventListener('click', () => {

    if (pause === false) {
        btnPause.innerText = "Play";
    } else if (pause === true) {
        btnPause.innerText = "Pause";
    }
    pause = !pause;

})

