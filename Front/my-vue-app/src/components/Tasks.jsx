import { Card, CardBody, CardFooter, CardHeader, Divider, Heading, Text } from '@chakra-ui/react';
import moment from'moment';
export default function TasksLists({ title, description, date }) {
    return (
        <Card variant={"filled"}>
            <CardHeader> 
                <Heading size={"md"}>{title}</Heading>
            </CardHeader>
            <Divider borderColor={"gray"} />
            <CardBody>
                <Text>{description}</Text>
            </CardBody>
            <Divider borderColor={"gray"} />
            <CardFooter>{moment(date).format("YYYY/MM/DD HH:mm:ss")}</CardFooter>
        </Card>
    );
}
