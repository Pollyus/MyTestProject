import React, { Component } from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
//import theme from '../theme'
import { Typography, Button } from '@mui/material';
import SendIcon from '@mui/icons-material/Send';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
        <Box >
            <Typography variant="h3" component="h2" > MyTests </Typography>
            <Typography variant="h5" component="h5" > Введите путь к тесту, namespace (если необходимо), job и id </Typography>
            <Box
        component="form"
        sx={{
            '& .MuiTextField-root': { m: 1, width: '100ch' },
        }}
    noValidate
    autoComplete="off"
        >
        <div>
     <TextField  pipeline
    id="outlined-required"
    label="Введите pipeline*"
    defaultValue="1"
        />
        <TextField
     job
    id="outlined-required"
    label=" job*"
    defaultValue="20"
        />
        <TextField

    
    id="outlined-required"
    
    defaultValue="C:\Учеба\Практика\MyCalc\MyCalcTests\MyCalcTests.csproj"
        />
        </div>
    </Box>
    <Button variant="contained" backgroundColor='#8884d8' endIcon={<SendIcon />}>
        Запустить выполнение теста
    </Button>

    </Box>
    );
}
}