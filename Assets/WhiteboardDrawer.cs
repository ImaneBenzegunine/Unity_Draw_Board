using UnityEngine;

public class WhiteboardDrawer : MonoBehaviour
{
    public Camera cam;
    public RenderTexture renderTexture;
    public Color drawColor = Color.black;
    public int brushSize = 10;

    private Texture2D tex;
    private RaycastHit hit;
    private Vector2? lastDrawUV = null;
    private bool needsUpdate = false;

    void Start()
    {
        tex = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);
        ClearTexture();

        RenderTexture.active = renderTexture;
        Graphics.Blit(tex, renderTexture);
        RenderTexture.active = null;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Vector2 uv = hit.textureCoord;
                    if (lastDrawUV != null)
                    {
                        DrawLine(lastDrawUV.Value, uv);
                    }
                    else
                    {
                        DrawAt(uv);
                    }

                    lastDrawUV = uv;
                }
            }
        }
        else
        {
            lastDrawUV = null;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearBoard();
        }

        // ✅ Only apply changes once per frame if needed
        if (needsUpdate)
        {
            tex.Apply();
            RenderTexture.active = renderTexture;
            Graphics.Blit(tex, renderTexture);
            RenderTexture.active = null;
            needsUpdate = false;
        }
    }

    void DrawLine(Vector2 startUV, Vector2 endUV)
    {
        int steps = (int)(Vector2.Distance(startUV, endUV) * tex.width * 2);
        for (int i = 0; i <= steps; i++)
        {
            float t = (float)i / steps;
            Vector2 interpolated = Vector2.Lerp(startUV, endUV, t);
            DrawAt(interpolated);
        }
    }

    void DrawAt(Vector2 uv)
    {
        int x = (int)(uv.x * tex.width);
        int y = (int)(uv.y * tex.height);

        for (int i = -brushSize; i <= brushSize; i++)
        {
            for (int j = -brushSize; j <= brushSize; j++)
            {
                int px = x + i;
                int py = y + j;
                if (px >= 0 && px < tex.width && py >= 0 && py < tex.height)
                {
                    tex.SetPixel(px, py, drawColor);
                    needsUpdate = true;
                }
            }
        }
    }

    void ClearTexture()
    {
        Color[] colors = new Color[tex.width * tex.height];
        for (int i = 0; i < colors.Length; i++)
            colors[i] = Color.white;

        tex.SetPixels(colors);
        tex.Apply();

        RenderTexture.active = renderTexture;
        Graphics.Blit(tex, renderTexture);
        RenderTexture.active = null;
    }

    public void ClearBoard()
    {
        ClearTexture();
    }
}
