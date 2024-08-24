import ReactDOOM from "react-dom/client";
import App from "./App";
import "./index.css";
import {ChakraProvider} from "@chakra-ui/react";

ReactDOOM.createRoot(document.getElementById("root")).render(
  <ChakraProvider>
    <App />
  </ChakraProvider>

)