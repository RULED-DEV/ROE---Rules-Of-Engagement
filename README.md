unity game project ROE - Rules Of Engagement from 2025 (abandoned due to complexity). game featured physics based ships that moved and rotated through
2d space, orders were given to ships by players and then resolved simultaneously during a simulation phase.

requirements :
  - OS that can run unity editor.
  - unity installed on machine to run the editor.
  - a unity version to run the project in.

install instructions :
    - download repository and unzip.
    - open unity hub and click add then add project from disk.
    - navigate and select unzipped repository.
    - you will be prompted for a version to open it in, selecting missing version or latest LTS version will work best.
    - wait for editor to load and enjoy.

gameplay notes :

command and controls : 
  - players would select ships using the mouse and then issue a set of commands allowing the ship to accelerate
    in a given direction, rotate to a given bearing, move to a position or even orbit. holding shift the player could give multiple sequential commands.

  - each command is represented by a line leading from the ship/prior command, the length of the line would dictate how long the command lasted for or
    what position the command would reference to move to/point at.

  - players could also use the number keys to select the weapons the ship had equipped and could click at a point in space or on a target so that the
    ship would attack it.

  - these commands would give the player a large ability to control their ships and dictate their corresponding actions however the sheer number of
    commands implemented bloated the original system.

ships : 
  - ships were composed of components which each contributed to the ships stats, generators would create energy at regular intervals while batteries
    stored the energy and these systems would reference each other to determine if they could function such as weapons referencing ammo stockpiles to
    see if they could fire.

  - each of these systems fit into an individual compartment of the ship which aggregated their values into a more readable format, these compartments
    would also contribute to the ships mass which would make larger ships slower, each compartment also had its own health value allowing ships to
    be slowly destroyed piece by piece, losing attached components with each lost compartment.

please direct all inquiries, questions and problems to ruled.dev@gmail.com
