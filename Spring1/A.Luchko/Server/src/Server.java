/*import java.net.*;
import java.io.*;
public class Server {
    public static void main(String[] ar)    {
        int port = 6666; // случайный порт (может быть любое число от 1025 до 65535)
        try {
            ServerSocket ss = new ServerSocket(port); // создаем сокет сервера и привязываем его к вышеуказанному порту
            System.out.println("Waiting for a client...");

            Socket socket = ss.accept(); // заставляем сервер ждать подключений и выводим сообщение когда кто-то связался с сервером
            System.out.println("Got a client :) ... Finally, someone saw me through all the cover!");
            System.out.println();

            // Берем входной и выходной потоки сокета, теперь можем получать и отсылать данные клиенту.
            InputStream sin = socket.getInputStream();
            OutputStream sout = socket.getOutputStream();

            // Конвертируем потоки в другой тип, чтоб легче обрабатывать текстовые сообщения.
            DataInputStream in = new DataInputStream(sin);
            DataOutputStream out = new DataOutputStream(sout);

            String line = null;
            while(true) {
                line = in.readUTF(); // ожидаем пока клиент пришлет строку текста.
                System.out.println("The dumb client just sent me this line : " + line);
                System.out.println("I'm sending it back...");
                out.writeUTF(line); // отсылаем клиенту обратно ту самую строку текста.
                out.flush(); // заставляем поток закончить передачу данных.
                System.out.println("Waiting for the next line...");
                System.out.println();
            }
        } catch(Exception x) { x.printStackTrace(); }
    }
}*/
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;

import javax.swing.text.Document;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.soap.Node;
import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.logging.XMLFormatter;


import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;


public class Server
{
    public static boolean findDay(String day, String[] array)
    {
        // String[] days = getResources().getStringArray(R.array.daysofyearforcode);
        for(String a: array)
        {
            if (day.equals(a)) return true;
        }
        return false;
    }
    public static void main(String[] args) throws IOException {

        ServerSocket servsocket = new ServerSocket(3000);
        String[] MyPhoto=null;
        try {
            File myPhoto = new File("C:\\Users\\Alex\\Desktop\\project\\myPhoto.xml");
            // String[] days = .getStringArray("MyPhoto");
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            DocumentBuilder dbs = dbf.newDocumentBuilder();
            org.w3c.dom.Document doc= dbs.parse(myPhoto);
            doc.getDocumentElement().normalize();
            System.out.println("Root Elements {"+doc.getDocumentElement().getNodeName()+" }");
            NodeList nodelist=doc.getElementsByTagName("item");
            System.out.println("Items");
            System.out.println("количество элементов "+nodelist.getLength());
            MyPhoto=new String[nodelist.getLength()];
            for(int je=0;je<nodelist.getLength();je++)
            {

                org.w3c.dom.Node fstNode=nodelist.item(je);
                if(fstNode.getNodeType()==Node.ELEMENT_NODE)
                {
                    Element esd=(Element) fstNode;
                    System.out.println(esd.getAttribute("name"));
                    MyPhoto[je]=esd.getAttribute("name");
                }
            }
        }
        catch (Exception e)
        {
System.out.println(e.toString());
        }

        String line = null;
        while (true)
        {
            Socket sock = servsocket.accept();
            InputStream sin = sock.getInputStream();
            DataInputStream in = new DataInputStream(sin);
            line = in.readUTF(); // ожидаем пока клиент пришлет строку текста.

            System.out.println("result: " + line);
            System.out.println("result: "+findDay(line,MyPhoto));
            if(findDay(line,MyPhoto))
            {
                File myFile = new File("C:\\Users\\Alex\\Desktop\\project\\"+line+".bmp");
                OutputStream sout = sock.getOutputStream();

                // Конвертируем потоки в другой тип, чтоб легче обрабатывать текстовые сообщения.

                DataOutputStream out = new DataOutputStream(sout);
                out.writeUTF("true");
                out.flush();
                byte[] mybytearray = new byte[(int) myFile.length()];
                int length=(int)myFile.length();
                String lengthForFile=Integer.toString(length);
                out.writeUTF(lengthForFile);
                BufferedInputStream bis = new BufferedInputStream(new FileInputStream(myFile));
                bis.read(mybytearray, 0, mybytearray.length);
                OutputStream os = sock.getOutputStream();
                os.write(mybytearray, 0, mybytearray.length);
                os.flush();
                sock.close();
                System.out.println("послал!");
            }
            else
            {
                OutputStream sout = sock.getOutputStream();
                // Конвертируем потоки в другой тип, чтоб легче обрабатывать текстовые сообщения.
                DataOutputStream out = new DataOutputStream(sout);
                out.writeUTF("false"); // отсылаем клиенту обратно ту самую строку текста.
                out.flush();
                sock.close();
                System.out.println("не послал!");
            }
        }
    }
}