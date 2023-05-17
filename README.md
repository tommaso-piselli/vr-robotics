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