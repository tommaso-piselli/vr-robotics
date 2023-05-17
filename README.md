# Immersive Robotics
Progetto per la visualizzazione di Topic da Ros a Unity in un ambiente di Realtà Aumentata.

## Index
- [Oculus Setup](https://github.com/tommaso-piselli/passthrough-robotics/edit/main/README.md#step-1-oculus-setup)


## STEP 1: Oculus Setup
- Nell'Editor di Unity, creare un progetto `3D(URP)`.
- Una volta aperto, andare su `Window > Asset Store > Search Online` e aprire la pagina nel web browser.
- Scaricare il pacchetto `Oculus Integration`. Dopo di che lo si apra nell'editor e si proceda con l'istallazione.
    - Qualora sia già stato scaricato in precedenza, nell'editor di Unity andare su `Package Manager` in alto nel menù a tendina selezionare `Packages: My Assets > Oculus Integration`. Selezionare `Download` e quindi `Import`.
- Compariranno delle finestre: selezionare Use `Open XR > Upgrade > Restart`.
- A questo punto si deve impostare il progetto per poter lavorare sul Meta Quest. Cliccare su `File > Build Settings` e switchare piattaforma ad `Android` (Qualora si volesse buildare il progetto all'interno del visore). Altrimenti rimanere su `PC, Mac & Linux standalone` per continuare a utilizzare il computer.
- Cliccare su `Edit > Project Settings > XR Plugin Management > Install Plugin Management`
- Selezionare la piattaforma che si intende utilizzare e selezionare il plug-in `Oculus`.
- Per abilitare *passthrough* si devono verificare le seguenti proprietà: `Project Settings > Player` verificare che `Rendering > Color Space` sia settato a `Linear`; sotto `Configuration > Scripting Backend` verificare che sia selezionato `IL2CPP`; nello stesso spazio verificare che la `Target Architecture` sia `ARM64`.

## STEP 2: Project Setup in Unity
- Andare su `Window > Package Manager > My Assets` e importare `Oculus Integration`.
    - Qualora non fosse stato precedentemente scaricato, si deve andare su `Asset Store > Search Online > Oculus Integration`. A questo punto, nell'editor di Unity si dovrà andare su `Package Manager > Oculus Integration > Download`. Da qui in poi le istruzioni seguono quelle riportate nel punto precedente.
    - Durante l'import compariranno dei prompt con delle richieste. Si deve continuare a inserire l'opzione consigliata come `Restart | Upgrade | Clean Up (Recommended)`.
- Una volta importato il package `Oculus Integration` andare su `XR-Plugin Management` e selezionare `Oculus` per la piattaforma scelta come build (`Android` per la standalone o `PC` per la cablata).
- A seguire andare su `Edit > Project Settings` e selezionare la voce `Oculus`:
    - Qui si dovranno fixare i problemi cliccando sul pulsante `Fix All` della build scelta.
- Andare quindi su `Player` per cambiare il nome del progetto in `Product Name` e dell'autore in `Company Name`.

## STEP 3: Scene Setup
- Nell'editor di Unity, si vada nella Hierarchy e si elimini il `Main Camera` Object.
- Nella finestra del `Project` si importi sulla scena `OVRCameraRig`. Questo sarà l'oggetto più importante in quanto controllerà il comportamento del visore.
- Aprire `OVRCameraRig` nell'Ispector ed eseguire le seguenti modifiche:
    - Nella sezione `General`:
        - `Tracking Origin Type` da settare a `Floor Level`
        - `Hand Tracking Support` da settare a `Controllers and Hands`
        - `Passthrough Support` da settare a `Required`
    - Nella sezione `Experimental`:
        - Spunta ON su `Experimental Features Enable`
    - Spunta ON su `Enable Passthrough`
- Su `OVRCameraRig` aggiungere il componente `OVR Passthrough Layer` e settare il seguente parametro:
    - `Placement` su `Underlay`
- A questo punto nella Hierarchy, si espanda `OVRCameraRig`. Selezionare `CenterEyeAnchor` e aprirlo nell'Inspector. Nel component `Camera`, alla sezione `Environment`, modificare `Background Type` su `Solid Color` e scegliere un colore neutro (es. nero).
