# ✏️ Unity Whiteboard Drawer

A simple interactive whiteboard system for Unity that allows users to draw on a virtual whiteboard using mouse input.

![Capture](https://github.com/user-attachments/assets/fb76690a-4b56-41fa-85fa-ea89ed023ffd)

*Example of drawing on the whiteboard*

![image](https://github.com/user-attachments/assets/5a476346-47fa-4553-a5ac-1aca84a4692b)

*Inspector configuration for the WhiteboardDrawer component*

##  Features

- Real-time drawing on a whiteboard texture
- Adjustable brush size and color
- Smooth line drawing between points
- Clear functionality (press 'C' key)
- Optimized texture updates
- Configurable via Unity Inspector

##  Setup

1. Attach the `WhiteboardDrawer` script to your whiteboard GameObject
2. Assign the required references in the Inspector:
   - Main Camera (for raycasting)
   - Render Texture (target for drawing)
3. Configure brush settings:
   - Draw Color
   - Brush Size

##  Controls

- **Left Mouse Button**: Draw on the whiteboard
- **C Key**: Clear the whiteboard


##  Technical Details

- Uses RenderTexture for drawing surface
- Implements line interpolation for smooth drawing
- Optimized texture updates (only when changes occur)
- Raycasting to detect whiteboard surface


## 📜 License

MIT License - Feel free to use and modify this project for your needs.

Imane BENZEGUNINE
LINKEDIN: https://www.linkedin.com/in/imane-benzegunine/

You can copy this markdown directly into your README.md file. For the images referenced:
1. Save your test image as `whiteboard-example.png`
2. Save your inspector configuration screenshot as `inspector-config.png`
3. Place both in your project's root directory before pushing to GitHub

Would you like me to modify any part of this README or suggest additional sections?
